export class ListingBook {
    id: number;
    title: string;
    description: string;
    author: string;
    genre: string;
    modified: Date;
}

export class EditBook {
    id: number;
    title: string;
    description: string;
    authorId: number;
    genre: string;
}