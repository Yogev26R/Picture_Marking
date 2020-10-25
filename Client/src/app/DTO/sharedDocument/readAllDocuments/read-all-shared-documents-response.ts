import { Response } from '../../response';
import { ReadAllSharedDocumentsRequest } from './read-all-shared-documents-request';

export class ReadAllSharedDocumentsResponse extends Response {
    constructor(
        public request: ReadAllSharedDocumentsRequest
    ) {
        super();
    }
}
