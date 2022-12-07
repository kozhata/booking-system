import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../../url/url'

@Injectable()
export class BookService {
    private url!: string;

    constructor(private _http: HttpClient) {
        this.url = apiUrl.url
    };

    createBook(body: any) {
        return this._http.post<void>(this.url + '/api/bookings/create', body);
    }
}
