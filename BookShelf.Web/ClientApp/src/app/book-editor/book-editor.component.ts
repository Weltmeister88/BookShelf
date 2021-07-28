import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EditBook } from '../models/books';
import { BooksService } from '../services/books.service';
import { Observable } from "rxjs";

@Component({
  selector: 'app-book-editor',
  templateUrl: './book-editor.component.html'
})

export class BookEditorComponent {
  public book: Observable<EditBook>;

  constructor(private readonly service: BooksService) {
  }
}