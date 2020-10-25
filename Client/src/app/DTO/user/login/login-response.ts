import { LoginRequest } from './login-request';
import { Response } from '../../response';

export class LoginResponse extends Response {
    constructor(public request: LoginRequest) {
        super();
    }
}
