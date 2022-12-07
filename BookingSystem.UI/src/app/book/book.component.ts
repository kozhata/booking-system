import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { IBooking } from '../interfaces';
import { BookService } from './book.service'

@Component({
  selector: 'book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnDestroy {
  private subs: Subscription | null = null;

  constructor(
    private _bookService: BookService
  ) { }

  onSubmit(data: IBooking) {
    if (this.subs) {
      this.subs.unsubscribe();
      this.subs = null;
    }

    this.subs = this._bookService.createBook(data).subscribe({
      next: () => { },
      error: error => {
        console.log(error);
      }
    })
  }

  ngOnDestroy(){
    if (this.subs) {
      this.subs.unsubscribe();
      this.subs = null;
    }
  }
}
