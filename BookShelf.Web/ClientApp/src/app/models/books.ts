export class ListingBook {
    id: number;
    title: string;
    description: number;
    author: string;
    genre: string;
    modified: Date;
}

export class EditBook {
    id: number;
    title: string;
    description: number;
    authorId: number;
    genre: string;
}