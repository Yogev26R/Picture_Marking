import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { DocumentDTO } from '../DTO/document/document-dto';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css']
})
export class DocumentComponent implements OnInit {
  @Input() document: DocumentDTO;
  @Input() isShared: boolean;
  @Output() deleteDocument: EventEmitter<any> = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  updateDocument() {
    this.router.navigate(['/documents', this.document.documentID], { state: { data: this.document } });
  }

  onDeleteDocument() {
    this.deleteDocument.emit();
  }
}
