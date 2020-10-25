import { DocumentDTO } from '../document-dto';

export class ReadDocumentRequest {
    constructor(
        public documentID: string,
        public documentDTO: DocumentDTO) { }
}
