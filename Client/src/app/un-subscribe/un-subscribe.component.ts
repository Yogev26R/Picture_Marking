import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UnSubscribeService } from '../services/user/un-subscribe.service';

@Component({
  selector: 'app-un-subscribe',
  templateUrl: './un-subscribe.component.html',
  styleUrls: ['./un-subscribe.component.css']
})
export class UnSubscribeComponent implements OnInit {

  constructor(
    private unSubscribeService: UnSubscribeService,
    private router: Router) { }

  ngOnInit(): void {
    this.unSubscribeService.onUnSubscribeResponseOK().subscribe(
      response => this.router.navigate(['/'])
    );

    this.unSubscribeService.unSubscribe();
  }

}
