import { DocumentDTO } from '../document-dto';

export class CreateDocumentRequest {
    constructor(public document: DocumentDTO) { }
}
