import { LoginDTO } from '../login/login-dto';

export class UnSubscribeDTO {
    constructor(
        public login: LoginDTO,
        public userID: string
    ) { }
}
