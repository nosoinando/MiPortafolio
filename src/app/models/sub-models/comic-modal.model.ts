import { ComicInfo } from "./comic-info.model"

export class ComicModalModel{
    uri: string
    isFavorite?: boolean = false
    comic_info?: ComicInfo
}