import { SharedDocumentDTO } from '../shared-document-dto';

export class CreateSharedDocumentRequest {
    constructor(public sharedDocument: SharedDocumentDTO) { }
}
