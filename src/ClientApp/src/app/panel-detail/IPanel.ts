import { ICircuit } from './ICircuit';

export interface IPanel {
  id: number;
  name: string;
  distSystemName: string;
  aicRating: string;
  busRating: number;
  mains: string;
  circuitLoadClassification: string;
  filePath: string;
  circuits: ICircuit[];
  mcbRating: number;
  mounting: string;
}
