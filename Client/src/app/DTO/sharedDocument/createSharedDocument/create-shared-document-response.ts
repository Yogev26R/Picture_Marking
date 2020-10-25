import { Response } from '../../response';
import { CreateSharedDocumentRequest } from './create-shared-document-request';

export class CreateSharedDocumentResponse extends Response {
    constructor(public request: CreateSharedDocumentRequest) {
        super();
    }
}
