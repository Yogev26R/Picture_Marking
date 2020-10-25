import { Injectable } from '@angular/core';
import { SubscribeService } from '../subscribe.service';
import { UserCommService } from './user-comm.service';
import { Subject } from 'rxjs';
import { UnSubscribeRequest } from 'src/app/DTO/user/unSubscribe/un-subscribe-request';
import { SessionService } from '../session.service';
import { LoginDTO } from 'src/app/DTO/user/login/login-dto';
import { UnSubscribeDTO } from 'src/app/DTO/user/unSubscribe/un-subscribe-dto';

@Injectable({
  providedIn: 'root'
})
export class UnSubscribeService extends SubscribeService {

  responseSubjects = {
    UnSubscribeResponseOK: new Subject<any>(),
    UnSubscribeResponseinvalidUserName: new Subject<any>(),
    UnSubscribeResponseinvalidEmailAddress: new Subject<any>()
  };

  constructor(
    private userCommService: UserCommService,
    private sessionService: SessionService) {
    super();
  }

  unSubscribe() {

    const loginDTO = new LoginDTO(this.sessionService.getUserName());
    const userID = this.sessionService.getUserID();
    console.log(loginDTO, userID);
    const unSubscribe = new UnSubscribeDTO(loginDTO, userID);
    const unSubscribeRequest = new UnSubscribeRequest(unSubscribe);
    this.subscribe(
      this.userCommService.unSubscribe(unSubscribeRequest),
      this.responseSubjects);
  }

  onUnSubscribeResponseOK() {
    return this.responseSubjects.UnSubscribeResponseOK;
  }

  onUnSubscribeResponseinvalidUserName() {
    return this.responseSubjects.UnSubscribeResponseinvalidUserName;
  }

  onUnSubscribeResponseinvalidEmailAddress() {
    return this.responseSubjects.UnSubscribeResponseinvalidEmailAddress;
  }

  logout() {
    this.sessionService.logout();
  }
}
