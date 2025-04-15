import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { expand, noop, of, takeWhile } from 'rxjs';
import { Character } from 'src/app/models/character.model';
import { Comic } from 'src/app/models/comic.model';
import { MarvelApiComponent } from 'src/app/services/marvel-api.service';
import { ComicsModalComponent } from '../comics-modal/comics-modal.component';
import { ComicModalModel } from 'src/app/models/sub-models/comic-modal.model';
import { ComicInfo } from 'src/app/models/sub-models/comic-info.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{
  characters: Character[] = [];
  loadedPage: boolean = false;
  length = 157;
  pageSize = 1;
  pageIndex = 0;
  pageEvent: PageEvent;
  orderBy: string = "name";
  filter: string = "";
  favorites: ComicInfo[] = [];
  constructor( private marvelService: MarvelApiComponent,
    private dialog: MatDialog,
    private router: Router) {}

  ngOnInit(){
    this.getCharacters(0);
  }

  handlePageEvent(e: PageEvent, filter: string) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageIndex = e.pageIndex;
    let offset = this.pageIndex * 10;
    if(filter != "" && this.orderBy != "name"){
      this.filterNsortCharacters(offset, filter);
    } else if(filter != ""){
      this.filterCharacters(offset, filter);
    } else if(this.orderBy != "name"){
      this.sortCharacters(offset);
    } else {
      this.getCharacters(offset);
    }
  }

  getCharacters(next: number){
    this.characters = [];
    this.marvelService.getCharacters(next).subscribe((data) => {
      data['data']['results'].forEach((element: Character) => {
        this.setCharactersData(element);
      });
      this.length = 157;
    });
  }

  filterCharacters(next: number, filter: string){
    this.characters = []
    if(filter == ""){
      this.getCharacters(0);
      this.pageIndex = 0;
    } else {
      this.marvelService.filterCharacters(filter, next).subscribe((data) => {
        data['data']['results'].forEach((element: Character) => {
          this.setCharactersData(element);
          console.log(element)
        });
        this.length = 10;
      });
    }
  }

  sortCharacters(next: number){
    this.characters = []
    this.marvelService.sortCharacters(this.orderBy, next).subscribe((data) => {
      data['data']['results'].forEach((element: Character) => {
        this.setCharactersData(element);
      });
      this.length = 10;
    });
  }

  filterNsortCharacters(next: number, filter: string){
    this.characters = [];
    this.marvelService.filterNsortCharacters(filter, this.orderBy, next).subscribe((data) => {
      data['data']['results'].forEach((element: Character) => {
        this.setCharactersData(element);
      });
      this.length = 10;
    });
  }

  setCharactersData(element: Character){
    let img = `${element.thumbnail.path}.${element.thumbnail.extension}`;
    element.thumbnail.path = img;
    let comicInfo: Comic[] = element.comics['items'];
    element.items = comicInfo;
    this.characters.push(element);
    this.loadedPage = true;
  }

  defineMethodCharacters(next: number){
    if(this.orderBy != 'name' && this.filter != ""){
      this.filterNsortCharacters(next, this.filter);
    } else if(this.orderBy != 'name'){
      this.sortCharacters(next);
    } else if(this.filter != ""){
      this.filterCharacters(next, this.filter);
    } else {
      this.getCharacters(next);
    }
  }

  openComicModal(comic: Comic){
    let modal_info: ComicModalModel = {
      uri: comic.resourceURI,
      isFavorite: false,
      comic_info: new ComicInfo()
    }
    const modal = this.dialog.open(ComicsModalComponent, {
      data: modal_info,
      width: "800px"
    });
    modal.afterClosed().subscribe((result: ComicModalModel) => {
      if(result.isFavorite && result.comic_info != undefined){
        this.favorites.push(result.comic_info);
      }
    });
  }

  removeFavorite(index: number){
    this.favorites.splice(index, 1)
  }

  goToDetail(id: number){
    this.router.navigate(['detail', id])
  }
}
