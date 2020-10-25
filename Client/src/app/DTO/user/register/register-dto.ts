import { LoginDTO } from '../login/login-dto';

export class RegisterDTO {
    constructor(
        public login: LoginDTO,
        public userID: string) { }
}
