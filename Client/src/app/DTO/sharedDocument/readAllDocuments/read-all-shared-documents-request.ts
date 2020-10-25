import { DocumentDTO } from '../../document/document-dto';

export class ReadAllSharedDocumentsRequest {
    constructor(
        public userID: string,
        public documents: Array<DocumentDTO>
    ) { }
}
