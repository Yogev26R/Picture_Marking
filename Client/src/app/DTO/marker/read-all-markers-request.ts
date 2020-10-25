import { MarkerDTO } from './marker-dto';

export class ReadAllMarkersRequest {
    constructor(
        public documentID: string,
        public markers: MarkerDTO[]
    ) { }
}
