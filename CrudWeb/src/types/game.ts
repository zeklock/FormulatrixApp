import type { GenreType } from "./genre";

export interface GameType {
  id: string;
  title: string;
  releaseYear: number;
  genre: GenreType | null;
}

export interface GameCreateType {
  title: string;
  releaseYear: number;
  genreId: string | null;
}

export interface GameUpdateType extends GameCreateType {
  id: string;
}
