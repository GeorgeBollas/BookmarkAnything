import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material';

import { EditListDialogComponent } from '../edit-list-dialog/edit-list-dialog.component'
import { BookmarkList } from '../services/bookmarks/bookmark-list.model';
import { BookmarkListService } from '../services/bookmarks/bookmark-list.service';

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html'
})
export class DashboardComponent {
  public lists: BookmarkList[];

  constructor(
    public dialog: MatDialog,
    http: HttpClient,
    bookmarkListService: BookmarkListService) {

    bookmarkListService.getBookmarkList().subscribe(result => {
      this.lists = result;
    }, error => console.error(error));
  }

  public newListDialog() {

    const dialogRef = this.dialog.open(EditListDialogComponent, {
      height: '400px',
      width: '600px',
      data: {name:''}
    });

    dialogRef.afterClosed().subscribe(result => {
      alert('The dialog was closed');
    });
  }
}

