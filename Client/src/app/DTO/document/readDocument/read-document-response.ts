import { Response } from '../../response';
import { ReadDocumentRequest } from './read-document-request';

export class ReadDocumentResponse extends Response {
    constructor(public request: ReadDocumentRequest) {
        super();
    }
}
