import { Response } from '../response';
import { ReadAllMarkersRequest } from './read-all-markers-request';

export class ReadAllMarkersResponse extends Response {
    constructor(public request: ReadAllMarkersRequest) {
        super();
    }
}
