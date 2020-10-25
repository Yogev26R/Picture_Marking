import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { webSocket, WebSocketSubject } from 'rxjs/webSocket';
import { DrawingDTO } from 'src/app/DTO/drawing/drawing-dto';
import { DrawingMsg } from 'src/app/DTO/drawing/drawing-msg';
import { SessionService } from '../session.service';

@Injectable({
  providedIn: 'root'
})
export class DrawingService {
  documentID: string;
  userID: string;
  socket: WebSocketSubject<any>;
  responseSubjects = {
    open: new Subject(),
    drawEllipse: new Subject<{ centerX, centerY, radiusX, radiusY }>(),
    drawRectangle: new Subject<{ centerX, centerY, radiusX, radiusY }>(),
    FreeDraw: new Subject<{ xcanvas, ycanvas, mouseX, mouseY }>(),
    close: new Subject()
  };

  shape2Subject = {
    Ellipse: this.responseSubjects.drawEllipse,
    Rectangle: this.responseSubjects.drawRectangle,
    FreeDraw: this.responseSubjects.FreeDraw
  };

  constructor(private sessionService: SessionService) { }

  Start(documentID) {
    this.documentID = documentID;
    this.userID = this.sessionService.getUserID();
    console.log('Service Start');
    this.socket = webSocket('ws://localhost:5001/ws?userid=' + this.userID + '&documentid=' + this.documentID);
    this.socket.asObservable().subscribe(
      response => {
        if (response.drawing.UserID !== this.userID) {
          console.log('draw response', response);
          console.log(response.drawing.DrawType);
          this.shape2Subject[response.drawing.DrawType].next(JSON.parse(response.drawing.DrawObj));
          console.log(response);
        }
      });
  }

  Send(drawType: string, drawObj: any) {
    const drawingDTO = new DrawingDTO(
      this.userID,
      this.documentID,
      drawType,
      JSON.stringify(drawObj));
    const drawingMsg = new DrawingMsg(drawingDTO);
    console.log(drawingDTO);
    console.log(drawingMsg);
    this.socket.next(drawingMsg);
  }

  Close() {
    this.socket.complete();
  }

  drawShape(drawType: string, drawObj: { centerX, centerY, radiusX, radiusY }) {
    console.log(drawType);
    console.log(drawObj);
    console.log(this.shape2Subject[drawType]);
    this.Send(drawType, drawObj);
    this.shape2Subject[drawType].next(drawObj);
  }

  freeDraw(xcanvas, ycanvas, mouseX, mouseY) {
    console.log(mouseX + ':' + mouseY);
    this.Send('FreeDraw', { xcanvas, ycanvas, mouseX, mouseY });
    this.responseSubjects.FreeDraw.next({ xcanvas, ycanvas, mouseX, mouseY });
  }

  onEllipseDraw() {
    return this.responseSubjects.drawEllipse;
  }

  onRectangleDraw() {
    return this.responseSubjects.drawRectangle;
  }

  onFreeDraw() {
    return this.responseSubjects.FreeDraw;
  }
}
