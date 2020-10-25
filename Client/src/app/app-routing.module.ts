import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateDocumentComponent } from './create-document/create-document.component';
import { DocumentsComponent } from './documents/documents.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UnSubscribeComponent } from './un-subscribe/un-subscribe.component';
import { UpdateDocumentComponent } from './update-document/update-document.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'unsubscribe', component: UnSubscribeComponent },
  { path: 'documents', component: DocumentsComponent },
  { path: 'documents/:id', component: UpdateDocumentComponent },
  { path: 'createdocument', component: CreateDocumentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
