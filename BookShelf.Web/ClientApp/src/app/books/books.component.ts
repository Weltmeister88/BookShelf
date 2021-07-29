import { Component } from '@angular/core';
import { ListingBook } from '../models/books';
import { BooksService } from '../services/books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html'
})

export class BooksComponent {
  public books: ListingBook[];

  constructor(private readonly service: BooksService) {
    this.load();
  }

  public load() : void {
    this.service.getAll().subscribe((data: ListingBook[]) => {
      this.books = data;
    });
  }

  public delete(id: number): void {
    this.service.delete(id).subscribe(() => {
      this.load();
    });
  }
}
