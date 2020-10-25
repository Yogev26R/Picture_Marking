import { Component, OnInit } from '@angular/core';
import { SessionService } from '../services/session.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private sessionService: SessionService) { }

  ngOnInit(): void {
  }

  isLoggedIn() {
    return this.sessionService.isLoggedIn();
  }

  getUserName() {
    return this.sessionService.getUserName();
  }
}
