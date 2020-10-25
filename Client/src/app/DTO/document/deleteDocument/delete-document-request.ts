import { DocumentDTO } from '../document-dto';

export class DeleteDocumentRequest {
    constructor(public document: DocumentDTO) { }
}
