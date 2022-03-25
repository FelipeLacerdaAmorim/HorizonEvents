import { Batch } from "./Batch";
import { SocialMedia } from "./SocialMedia";
import { Speaker } from "./Speaker";

export interface Event{
 id: number;
 local: string;
 eventDate?: Date;
 theme: string;
 numPeople: number;
 imageURL: string;
 phoneNumber: string;
 email: string;
 batches: Batch[];
 socialMedias: SocialMedia[];
 speakerEvents: Speaker[];
}
