import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ListingBook } from '../models/books';
import { EditBook } from '../models/books';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class BooksService {
  
  private readonly apiUrl = this.baseUrl + "api/book";

  constructor(private readonly httpClient: HttpClient, @Inject('BASE_URL') private readonly baseUrl: string) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getAll(): Observable<ListingBook[]> {
    return this.httpClient.get<ListingBook[]>(this.apiUrl)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  get(id : number): Observable<EditBook> {
    return this.httpClient.get<EditBook>(this.apiUrl + "/" + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  create(entity : EditBook): Observable<number> {
    return this.httpClient.post<number>(this.apiUrl, JSON.stringify(entity), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  update(entity : EditBook) {
    return this.httpClient.put(this.apiUrl + '/' + entity.id, JSON.stringify(entity), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  delete(id : number){
    return this.httpClient.delete(this.apiUrl + '/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  handleError(error) {
     let errorMessage = '';
     if(error.error instanceof ErrorEvent) {
       // Get client-side error
       errorMessage = error.error.message;
     } else {
       // Get server-side error
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     window.alert(errorMessage);
     return throwError(errorMessage);
  }

}