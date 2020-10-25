export class MarkerDTO {
    constructor(
        public documentID: string,
        public markerID: string,
        public markerType: string,
        public markerLocation: string,
        public markerColor: string,
        public userID: string
    ) { }
}
