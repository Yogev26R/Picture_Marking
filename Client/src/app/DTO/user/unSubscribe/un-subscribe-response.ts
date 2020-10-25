import { UnSubscribeRequest } from './un-subscribe-request';
import { Response } from '../../response';

export class UnSubscribeResponse extends Response {
    request: UnSubscribeRequest;
}
