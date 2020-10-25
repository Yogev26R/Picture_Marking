import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/user/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  msg: string;
  loginForm = new FormGroup({
    userName: new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  constructor(
    private loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
    this.loginService.onInvalidUserName().subscribe(
      response => this.msg = response.request.login.userName + ' Invalid User Name'
    );

    this.loginService.onLoginOK().subscribe(
      response => this.router.navigate(['documents'])
    );
  }

  get form() { return this.loginForm.controls; }

  onSubmit() {
    this.loginService.login(this.form);
  }

}
