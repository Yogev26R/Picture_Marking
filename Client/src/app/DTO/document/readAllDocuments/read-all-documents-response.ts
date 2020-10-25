import { Response } from '../../response';
import { ReadAllDocumentsRequest } from './read-all-documents-request';

export class ReadAllDocumentsResponse extends Response {
    constructor(
        public request: ReadAllDocumentsRequest
    ) {
        super();
    }
}
