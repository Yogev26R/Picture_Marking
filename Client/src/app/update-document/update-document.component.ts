import { Component, OnInit } from '@angular/core';
import { DocumentDTO } from '../DTO/document/document-dto';

@Component({
  selector: 'app-update-document',
  templateUrl: './update-document.component.html',
  styleUrls: ['./update-document.component.css']
})
export class UpdateDocumentComponent implements OnInit {
  document: DocumentDTO;

  constructor() { }

  ngOnInit(): void {
    this.document = history.state.data as DocumentDTO;
  }

}
