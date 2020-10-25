import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SubscribeService {

  errorSubject = new Subject<any>();

  constructor() { }

  subscribe(subscriber: Observable<any>, subjects: any) {
    subscriber.pipe(
      map(response => {
        console.log(response.responseType);
        return [subjects[response.responseType], response];
      }))
      .subscribe(([responseSubject, response]) =>
        responseSubject.next(response),
        error => this.onError().next(error),
        () => console.log('Communication Completed'));
  }

  onError(): Subject<any> {
    return this.errorSubject;
  }

}
