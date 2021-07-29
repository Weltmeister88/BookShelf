import { Component, OnInit } from '@angular/core';
import { EditBook } from '../models/books';
import { Genre } from '../models/genres';
import { Author } from '../models/authors';
import { BooksService } from '../services/books.service';
import { GenresService } from '../services/genres.service';
import { AuthorsService } from '../services/authors.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book-editor',
  templateUrl: './book-editor.component.html'
})

export class BookEditorComponent implements OnInit {
  public book: EditBook;
  public id: number;
  public isAdding: boolean;
  public genres: Genre[];
  public authors: Author[];
  public isLoading: boolean;

  constructor(private readonly booksService: BooksService,
    private readonly genresService: GenresService,
    private readonly authorsService: AuthorsService,
    private readonly actRoute: ActivatedRoute,
    private readonly router: Router) {
  }

  ngOnInit() {
    console.info("aabb");
    this.isLoading = true;
    this.id = this.actRoute.snapshot.params['id'];
    this.isAdding = !this.id;
    if (this.id) {
      this.booksService.get(this.id).subscribe((data: EditBook) => {
        this.book = data;
      });
    } else {
      this.book = new EditBook();
    }

    this.genresService.getAll().subscribe((data: Genre[]) => {
      this.genres = data;
    });
    
    this.authorsService.getAll().subscribe((data: Author[]) => {
      this.authors = data;
    });

    this.isLoading = false;
  }

  create() {
    this.booksService.create(this.book).subscribe((data: number) => {
      this.router.navigate(['books']);
    });
  }

  update() {
    this.booksService.update(this.book).subscribe(() => {
      this.router.navigate(['books']);
    });
  }

  cancel() {
    this.router.navigate(['books']);
  }
}