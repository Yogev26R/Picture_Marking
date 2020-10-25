export class DrawingDTO {
    constructor(
        public UserID: string,
        public DocumentID: string,
        public DrawType: string,
        public DrawObj: string
    ) { }
}
