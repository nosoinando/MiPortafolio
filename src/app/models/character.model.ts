import { Comic } from "./comic.model"
import { Event } from "./event.model"
import { Picture } from "./picture.model"
import { Serie } from "./serie.model"
import { Story } from "./story.model"
import { Url } from "./url.model"

export class Character{
    id: number
    name: string
    description: string
    items: Comic[]
    comics: any
    thumbnail: Picture
    events?: any
    series: any
    stories?: any
    series_items: Comic[]
    events_items: Comic[]
    stories_items: Comic[]
    urls?: Url[]
    modified: string
}
