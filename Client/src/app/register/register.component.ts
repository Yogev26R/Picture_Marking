import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../services/user/register.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RegisterResponseOK } from '../DTO/user/register/register-response-ok';
import { RegisterResponseUserNameExists } from '../DTO/user/register/register-response-user-name-exists';
import { RegisterResponseEmailAddressExists } from '../DTO/user/register/register-response-email-address-exists';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  msg: string;
  registerForm = new FormGroup({
    emailAddress: new FormControl('', [Validators.required, Validators.minLength(6), Validators.email]),
    userName: new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  constructor(private registerService: RegisterService) { }

  ngOnInit(): void {
    this.registerService.onRegisterOK().subscribe(
      response => this.registerOK(response)
    );

    this.registerService.onRegisterUserNameExists().subscribe(
      response => this.RegisterUserNameExists(response)
    );

    this.registerService.onRegisterEmailAddressExists().subscribe(
      response => this.RegisterEmailAddressExists(response)
    );
  }

  get form() { return this.registerForm.controls; }

  get userName() {
    return this.registerForm.get('userName');
  }

  get emailAddress() {
    return this.registerForm.get('emailAddress');
  }

  onSubmit() {
    console.log('onSubmit in component', this.form.userName.value);
    this.registerService.register(this.form);
  }

  registerOK(response: RegisterResponseOK) {
    this.msg = 'Registered as ' + response.request.register.login.userName;
  }

  RegisterUserNameExists(response: RegisterResponseUserNameExists) {
    this.userName.setErrors({ UserNameExists: response.request.register.login.userName });
  }

  RegisterEmailAddressExists(response: RegisterResponseEmailAddressExists) {
    this.emailAddress.setErrors({ EmailAddressExists: response.request.register.userID });
  }
}
