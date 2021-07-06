import { Frame } from "./frame";

export interface BowlingScores {
    frameScores: number[];
    rollScores: number[];
    cummulativeScores: number[];
    totalScore: number;
    pinsLeft: number;
    frames: Frame[];

}