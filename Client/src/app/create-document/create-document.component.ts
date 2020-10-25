import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateDocumentService } from '../services/document/create-document.service';

@Component({
  selector: 'app-create-document',
  templateUrl: './create-document.component.html',
  styleUrls: ['./create-document.component.css']
})
export class CreateDocumentComponent implements OnInit {
  msg: string;
  createDocumentForm = new FormGroup({
    documentName: new FormControl('', [Validators.required, Validators.minLength(6)]),
    imageURL: new FormControl('', [Validators.required, Validators.minLength(6)]),
  });

  constructor(
    private createDocumentService: CreateDocumentService,
    private router: Router) { }

  ngOnInit(): void {
    this.createDocumentService.onCreateDocumentResponseOK().subscribe(
      response => this.router.navigate(['/documents'])
    );
  }

  get form() { return this.createDocumentForm.controls; }

  onSubmit() {
    console.log('onSubmit in component', this.form.documentName.value);
    this.createDocumentService.create(this.form);
  }


}
