import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { UserCommService } from './services/user/user-comm.service';
import { UserRemoteCommService } from './services/user/user-remote-comm.service';
import { DocumentsComponent } from './documents/documents.component';
import { DocumentComponent } from './document/document.component';
import { CreateDocumentComponent } from './create-document/create-document.component';
import { UpdateDocumentComponent } from './update-document/update-document.component';
import { DocumentCommService } from './services/document/document-comm.service';
import { DocumentRemoteCommService } from './services/document/document-remote-comm.service';
import { DrawingComponent } from './drawing/drawing.component';
import { DeleteDocumentComponent } from './delete-document/delete-document.component';
import { UnSubscribeComponent } from './un-subscribe/un-subscribe.component';
import { SharedDocumentCommService } from './services/sharedDocument/shared-document-comm.service';
import { SharedDocumentRemoteCommService } from './services/sharedDocument/shared-document-remote-comm.service';
import { CreateSharedDocumentComponent } from './create-shared-document/create-shared-document.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    DocumentsComponent,
    DocumentComponent,
    CreateDocumentComponent,
    UpdateDocumentComponent,
    DrawingComponent,
    DeleteDocumentComponent,
    UnSubscribeComponent,
    CreateSharedDocumentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: UserCommService, useClass: UserRemoteCommService },
    { provide: DocumentCommService, useClass: DocumentRemoteCommService },
    { provide: SharedDocumentCommService, useClass: SharedDocumentRemoteCommService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
