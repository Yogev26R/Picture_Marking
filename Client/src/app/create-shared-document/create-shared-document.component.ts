import { Component, Input, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CreateSharedDocumentService } from '../services/sharedDocument/create-shared-document.service';

@Component({
  selector: 'app-create-shared-document',
  templateUrl: './create-shared-document.component.html',
  styleUrls: ['./create-shared-document.component.css']
})
export class CreateSharedDocumentComponent implements OnInit {
  @Input() documentID: string;
  msg: string;
  userName = new FormControl('', [Validators.required, Validators.minLength(6)]);

  constructor(private createShareDocumentService: CreateSharedDocumentService) { }

  ngOnInit(): void {
    this.createShareDocumentService.onInvalidUserName().subscribe(
      response => this.msg = response.request.sharedDocument.userName + ' Invalid User Name'
    );

    this.createShareDocumentService.onShareDocumentOK().subscribe(
      response => this.msg = 'Document is now shared with ' + response.request.sharedDocument.userName
    );
  }

  onShareBtnClick() {
    this.createShareDocumentService.createSharedDocument(this.userName.value, this.documentID);
  }
}
