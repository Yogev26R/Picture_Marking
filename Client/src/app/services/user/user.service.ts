import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  errorSubject = new Subject<any>();

  constructor() { }

  subscribe(subscriber: Observable<any>, subjects: any) {
    subscriber.pipe(
      map(response => {
        console.log(subjects);
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
