import { DocumentDTO } from '../document-dto';

export class ReadAllDocumentsRequest {
    constructor(
        public userID: string,
        public documents: Array<DocumentDTO>
    ) { }
}
