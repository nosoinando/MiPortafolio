import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { elementAt } from 'rxjs';
import { Character } from 'src/app/models/character.model';
import { Comic } from 'src/app/models/comic.model';
import { Serie } from 'src/app/models/serie.model';
import { MarvelApiComponent } from 'src/app/services/marvel-api.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit{
  currentCharacter: Character;
  loadedPage: boolean = false;

  constructor(private router: Router,
    private marvelService: MarvelApiComponent,
    private route: ActivatedRoute) {}

  ngOnInit(): void {
      const id: number = this.route.snapshot.params["id"];
      this.getCharacter(id);
  }

  getCharacter(id: number){
    this.marvelService.getCharacterById(id).subscribe((data) => {
      data['data']['results'].forEach((element: Character) => {
        let series: Comic[] = element.series['items'];
        element.series_items = series;
        let events: Comic[] = element.events['items'];
        element.events_items = events;
        let stories: Comic[] = element.stories['items'];
        element.stories_items = stories;
        let comicInfo: Comic[] = element.comics['items'];
        element.items = comicInfo;
        let img = `${element.thumbnail.path}.${element.thumbnail.extension}`;
        element.thumbnail.path = img;
        this.currentCharacter = element;
      })
      
      this.loadedPage = true;
    });
  }

  goHome(){
    this.router.navigate(['home']);
  }
}
