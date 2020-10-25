import { LoginDTO } from '../login/login-dto';
import { UnSubscribeDTO } from './un-subscribe-dto';

export class UnSubscribeRequest {
    constructor(public UnSubscribe: UnSubscribeDTO) { }
}
