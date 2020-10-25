import { AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { fromEvent, Subject } from 'rxjs';
import { switchMap, takeUntil, buffer } from 'rxjs/operators';
import { Point } from '../DTO/drawing/point';
import { DrawingService } from '../services/drawing/drawing.service';
import { ReadMarkerService } from '../services/marker/read-marker.service';

@Component({
  selector: 'app-drawing',
  templateUrl: './drawing.component.html',
  styleUrls: ['./drawing.component.css']
})
export class DrawingComponent implements OnInit, AfterViewInit, OnDestroy {
  @Input() imageSRC: string;
  @Input() documentID: string;
  @ViewChild('shapeCanvas') shapeCanvas: ElementRef;
  @ViewChild('drawingCanvas') drawingCanvas: ElementRef;
  mouseDown$: any;
  shapeType: string;
  poly: Subject<Point>;
  switchSubject: Subject<Point>;

  constructor(
    private drawingService: DrawingService,
    private readMarkerService: ReadMarkerService
  ) {
    this.poly = new Subject<Point>();
    this.switchSubject = new Subject<Point>();
    this.shapeType = 'Ellipse';
  }

  ngOnInit() {
    this.readMarkerService.readAllMarkers(this.documentID);

    this.readMarkerService.onReadMarkersResponseOK().subscribe(
      response => {
        response.request.markers.forEach(
          marker => {
            console.log(marker);

            const obj = JSON.parse(marker.markerLocation);

            console.log(obj);

            marker.markerType === 'Ellipse' ?
              this.drawingService.onEllipseDraw().next(obj) :
              this.drawingService.onRectangleDraw().next(obj);
          }
        );
      }
    );

    this.drawingService.onFreeDraw().subscribe(
      obj => {
        const canvas = this.drawingCanvas.nativeElement;
        const ctx2 = canvas.getContext('2d');
        const x = obj.xcanvas - obj.mouseX;
        const y = obj.ycanvas - obj.mouseY;
        ctx2.beginPath();
        ctx2.moveTo(x, y);
        ctx2.lineTo(obj.xcanvas, obj.ycanvas);
        ctx2.stroke();
        this.poly.next(new Point(x, y));
      });

    this.drawingService.onEllipseDraw().subscribe(
      obj => {
        this.clearCanvas();
        const ctx1 = this.shapeCanvas.nativeElement.getContext('2d');
        console.log(obj.centerY + ':' + obj.radiusX);
        ctx1.beginPath();
        ctx1.ellipse(obj.centerX, obj.centerY, obj.radiusX, obj.radiusY, 0, 0, 2 * Math.PI);
        ctx1.stroke();
      });

    this.drawingService.onRectangleDraw().subscribe(
      obj => {
        this.clearCanvas();
        const ctx1 = this.shapeCanvas.nativeElement.getContext('2d');
        console.log(obj.centerY + ':' + obj.radiusX);
        ctx1.beginPath();
        ctx1.rect(obj.centerX - obj.radiusX, obj.centerY - obj.radiusY, obj.radiusX * 2, obj.radiusY * 2);
        ctx1.stroke();
      });

    this.drawingService.Start(this.documentID);
  }

  ngAfterViewInit() {
    this.shapeCanvas.nativeElement.width = 1200;
    this.shapeCanvas.nativeElement.height = 800;
    const ctx1 = this.shapeCanvas.nativeElement.getContext('2d');
    const image = new Image();
    image.src = this.imageSRC;
    image.onload = ctx1.drawImage(image, 0, 0, image.width, image.height, 0, 0, 1200, 800);

    this.drawingCanvas.nativeElement.width = 1200;
    this.drawingCanvas.nativeElement.height = 800;
    const ctx2 = this.drawingCanvas.nativeElement.getContext('2d');
    const mouseUp$ = fromEvent(this.drawingCanvas.nativeElement, 'mouseup');
    const mousedown$ = fromEvent(this.drawingCanvas.nativeElement, 'mousedown');
    const draw$ = mousedown$.pipe(
      // restart counter on every click
      switchMap(event =>
        fromEvent(this.drawingCanvas.nativeElement, 'mousemove').pipe(
          takeUntil(mouseUp$)
        )));
    draw$.subscribe(evt => this.freeDraw(evt));

    this.poly.pipe(
      buffer(mouseUp$),
    ).subscribe(shapePoly => { this.clearCanvas(); this.drawShape(shapePoly); });
  }

  clearCanvas() {
    const canvas = this.drawingCanvas.nativeElement;
    const ctx2 = canvas.getContext('2d');
    ctx2.clearRect(0, 0, this.drawingCanvas.nativeElement.width, this.drawingCanvas.nativeElement.height);
  }

  freeDraw(evt) {
    const canvas = this.drawingCanvas.nativeElement;
    const ctx2 = canvas.getContext('2d');
    const rect = canvas.getBoundingClientRect();
    const xcanvas = evt.clientX - rect.left;
    const ycanvas = evt.clientY - rect.top;
    this.drawingService.freeDraw(xcanvas, ycanvas, evt.movementX, evt.movementY);
  }

  drawShape(shapePoly: Array<Point>) {
    if (shapePoly.length > 0) {
      let center = new Point(0, 0);
      center = shapePoly.reduce((acc, pt) => acc.add(pt));
      center = center.div(shapePoly.length);
      let radius = new Point(0, 0);
      radius = shapePoly.reduce((acc, pt) => acc.add(new Point(Math.abs(pt.X - center.X), Math.abs(pt.Y - center.Y))));
      radius = radius.div(shapePoly.length);
      const shapeObj = { centerX: center.X, centerY: center.Y, radiusX: radius.X, radiusY: radius.Y };
      console.log(shapeObj);

      this.drawingService.drawShape(this.shapeType, shapeObj);
    }
  }

  setShape(shapeType: string) {
    this.shapeType = shapeType;
  }

  ngOnDestroy(): void {
    this.drawingService.Close();
  }
}
