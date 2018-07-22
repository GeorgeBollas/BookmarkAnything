import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BookmarkList } from './bookmark-list.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BookmarkListService {

  bookmarkList: BookmarkList[];

  constructor(private http: HttpClient,
    @Inject('BASE_URL')  private baseUrl: string) { }

  getBookmarkList() : Observable<BookmarkList[]> {
    return this.http.get<BookmarkList[]>(this.baseUrl + 'api/BookmarkList');
  }

}
