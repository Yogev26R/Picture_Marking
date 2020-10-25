import { RegisterRequest } from './register-request';
import { Response } from '../../response';

export class RegisterResponse extends Response {
    request: RegisterRequest;
}
