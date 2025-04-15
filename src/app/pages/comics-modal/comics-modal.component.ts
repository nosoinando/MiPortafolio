import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ComicInfo } from 'src/app/models/sub-models/comic-info.model';
import { ComicModalModel } from 'src/app/models/sub-models/comic-modal.model';
import { MarvelApiComponent } from 'src/app/services/marvel-api.service';

@Component({
  selector: 'app-comics-modal',
  templateUrl: './comics-modal.component.html',
  styleUrls: ['./comics-modal.component.scss']
})
export class ComicsModalComponent implements OnInit{
  comic: ComicInfo;
  loadedComic: boolean = false;
  constructor(public dialogRef: MatDialogRef<ComicsModalComponent>,
    private marvelService: MarvelApiComponent,
    @Inject(MAT_DIALOG_DATA) public data: ComicModalModel) {}

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.getComic();
  }

  getComic(){
    let id = this.getComicId();
    this.marvelService.getComicById(id).subscribe(data => {
      this.comic = data['data']['results'][0];
      let img = `${this.comic.images[0].path}.${this.comic.images[0].extension}`;
      this.comic.images[0].path = img;
      this.loadedComic = true;
    })
  }

  isFavorite(){
    if(!this.data.isFavorite){
      this.data.isFavorite = true;
      this.data.comic_info = this.comic;
    } else {
      this.data.isFavorite = false;
      this.data.comic_info = undefined;
    }
  }

  getComicId() : string{
    let info = this.data.uri.split('/');
    let id = info.slice(-1);
    return id[0];
  }

  closeModal(){
    this.dialogRef.close(this.data);
  }
}
