import { LoginDTO } from './login-dto';

export class LoginRequest {
    constructor(
        public login: LoginDTO,
        public userID: string
    ) { }
}
