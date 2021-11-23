import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl

fim = ctrl.Antecedent(np.arange(0, 127, 1), 'fim')
hand_strength = ctrl.Antecedent(np.arange(0, 5.1, 0.1), 'hand_strength')
leg_strength = ctrl.Antecedent(np.arange(0, 5.1, 0.1), 'leg_strength')
age = ctrl.Antecedent(np.arange(20, 71, 1), 'age')

time_hand = ctrl.Consequent(np.arange(5, 61, 1), 'time_hand')
hand_level = ctrl.Consequent(np.arange(1, 11, 1), 'hand_level')
time_leg = ctrl.Consequent(np.arange(5, 61, 1), 'time_leg')
leg_level = ctrl.Consequent(np.arange(1, 11, 1), 'leg_level')

fim['dependence'] = fuzz.trimf(fim.universe, [0, 27,54])
fim['need_help'] = fuzz.trimf(fim.universe,[36,63, 90])
fim['independence'] = fuzz.trimf(fim.universe,[72, 99,126])



hand_strength['non_activation'] = fuzz.trimf(hand_strength.universe,  [0,0,1.1])
hand_strength['non_range'] = fuzz.trimf(hand_strength.universe,[0.9,1.5,2.1])
hand_strength['weak'] = fuzz.trimf(hand_strength.universe,[1.9,2.5, 3.1])
hand_strength['rather'] = fuzz.trimf(hand_strength.universe,[2.9, 3.5,4.1])
hand_strength['normal'] = fuzz.trimf(hand_strength.universe,[3.9, 5,5])



leg_strength['non_activation'] = fuzz.trimf(leg_strength.universe,  [0,0,1.1])
leg_strength['non_range'] = fuzz.trimf(leg_strength.universe,[0.9,1.5,2.1])
leg_strength['weak'] = fuzz.trimf(leg_strength.universe,[1.9,2.5, 3.1])
leg_strength['rather'] = fuzz.trimf(leg_strength.universe,[2.9, 3.5,4.1])
leg_strength['normal'] = fuzz.trimf(leg_strength.universe,[3.9, 5,5])



age['young'] = fuzz.trimf(age.universe,[20, 33,45])
age['middle'] = fuzz.trimf(age.universe,[40, 52,65])
age['old'] = fuzz.trimf(age.universe,[60, 65,70])



time_hand['level1'] = fuzz.trimf(time_hand.universe, [5, 5, 10])
time_hand['level2'] = fuzz.trimf(time_hand.universe, [5, 10, 15])
time_hand['level3'] = fuzz.trimf(time_hand.universe, [10, 15, 20])
time_hand['level4'] = fuzz.trimf(time_hand.universe, [15, 20, 25]) 
time_hand['level5'] = fuzz.trimf(time_hand.universe, [20, 25, 30]) 
time_hand['level6'] = fuzz.trimf(time_hand.universe, [25, 30, 35]) 
time_hand['level7'] = fuzz.trimf(time_hand.universe, [30, 35, 40]) 
time_hand['level8'] = fuzz.trimf(time_hand.universe, [35, 40, 45]) 
time_hand['level9'] = fuzz.trimf(time_hand.universe, [40, 45, 50]) 
time_hand['level10'] = fuzz.trimf(time_hand.universe, [45, 50, 55]) 
time_hand['level11'] = fuzz.trimf(time_hand.universe, [50, 55, 60]) 
time_hand['level12'] = fuzz.trimf(time_hand.universe, [55, 60, 60]) 



hand_level['level1'] = fuzz.trimf(hand_level.universe, [1, 1, 2])
hand_level['level2'] = fuzz.trimf(hand_level.universe, [1, 2, 3])
hand_level['level3'] = fuzz.trimf(hand_level.universe, [2, 3, 4])
hand_level['level4'] = fuzz.trimf(hand_level.universe, [3, 4, 5])
hand_level['level5'] = fuzz.trimf(hand_level.universe, [4, 5, 6])
hand_level['level6'] = fuzz.trimf(hand_level.universe, [5, 6, 7])
hand_level['level7'] = fuzz.trimf(hand_level.universe, [6, 7, 8])
hand_level['level8'] = fuzz.trimf(hand_level.universe, [7, 8, 9])
hand_level['level9'] = fuzz.trimf(hand_level.universe, [8, 9, 10])
hand_level['level10'] = fuzz.trimf(hand_level.universe, [9, 10, 10])



time_leg['level1'] = fuzz.trimf(time_leg.universe, [5, 5, 10])
time_leg['level2'] = fuzz.trimf(time_leg.universe, [5, 10, 15])
time_leg['level3'] = fuzz.trimf(time_leg.universe, [10, 15, 20])
time_leg['level4'] = fuzz.trimf(time_leg.universe, [15, 20, 25]) 
time_leg['level5'] = fuzz.trimf(time_leg.universe, [20, 25, 30]) 
time_leg['level6'] = fuzz.trimf(time_leg.universe, [25, 30, 35]) 
time_leg['level7'] = fuzz.trimf(time_leg.universe, [30, 35, 40]) 
time_leg['level8'] = fuzz.trimf(time_leg.universe, [35, 40, 45]) 
time_leg['level9'] = fuzz.trimf(time_leg.universe, [40, 45, 50]) 
time_leg['level10'] = fuzz.trimf(time_leg.universe, [45, 50, 55]) 
time_leg['level11'] = fuzz.trimf(time_leg.universe, [50, 55, 60]) 
time_leg['level12'] = fuzz.trimf(time_leg.universe, [55, 60, 60]) 



leg_level['level1'] = fuzz.trimf(leg_level.universe, [1, 1, 2])
leg_level['level2'] = fuzz.trimf(leg_level.universe, [1, 2, 3])
leg_level['level3'] = fuzz.trimf(leg_level.universe, [2, 3, 4])
leg_level['level4'] = fuzz.trimf(leg_level.universe, [3, 4, 5])
leg_level['level5'] = fuzz.trimf(leg_level.universe, [4, 5, 6])
leg_level['level6'] = fuzz.trimf(leg_level.universe, [5, 6, 7])
leg_level['level7'] = fuzz.trimf(leg_level.universe, [6, 7, 8])
leg_level['level8'] = fuzz.trimf(leg_level.universe, [7, 8, 9])
leg_level['level9'] = fuzz.trimf(leg_level.universe, [8, 9, 10])
leg_level['level10'] = fuzz.trimf(leg_level.universe, [9, 10, 10])


rule1 = ctrl.Rule(fim['dependence']&age['old']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule2 = ctrl.Rule(fim['dependence']&age['old']&hand_strength['non_range'],(time_hand['level1'],hand_level['level2']))
rule3 = ctrl.Rule(fim['dependence']&age['old']&hand_strength['weak'],(time_hand['level1'],hand_level['level3']))
rule4 = ctrl.Rule(fim['dependence']&age['old']&hand_strength['rather'],(time_hand['level2'],hand_level['level4']))
rule5 = ctrl.Rule(fim['dependence']&age['old']&hand_strength['normal'],(time_hand['level2'],hand_level['level4']))

rule6 = ctrl.Rule(fim['dependence']&age['middle']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule7 = ctrl.Rule(fim['dependence']&age['middle']&hand_strength['non_range'],(time_hand['level2'],hand_level['level2']))
rule8 = ctrl.Rule(fim['dependence']&age['middle']&hand_strength['weak'],(time_hand['level3'],hand_level['level3']))
rule9 = ctrl.Rule(fim['dependence']&age['middle']&hand_strength['rather'],(time_hand['level4'],hand_level['level4']))
rule10 = ctrl.Rule(fim['dependence']&age['middle']&hand_strength['normal'],(time_hand['level4'],hand_level['level6']))

rule11 = ctrl.Rule(fim['dependence']&age['young']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule12 = ctrl.Rule(fim['dependence']&age['young']&hand_strength['non_range'],(time_hand['level2'],hand_level['level2']))
rule13 = ctrl.Rule(fim['dependence']&age['young']&hand_strength['weak'],(time_hand['level3'],hand_level['level4']))
rule14 = ctrl.Rule(fim['dependence']&age['young']&hand_strength['rather'],(time_hand['level4'],hand_level['level6']))
rule15 = ctrl.Rule(fim['dependence']&age['young']&hand_strength['normal'],(time_hand['level6'],hand_level['level8']))

rule16 = ctrl.Rule(fim['need_help']&age['old']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule17 = ctrl.Rule(fim['need_help']&age['old']&hand_strength['non_range'],(time_hand['level2'],hand_level['level2']))
rule18 = ctrl.Rule(fim['need_help']&age['old']&hand_strength['weak'],(time_hand['level3'],hand_level['level3']))
rule19 = ctrl.Rule(fim['need_help']&age['old']&hand_strength['rather'],(time_hand['level4'],hand_level['level4']))
rule20 = ctrl.Rule(fim['need_help']&age['old']&hand_strength['normal'],(time_hand['level5'],hand_level['level5']))

rule21 = ctrl.Rule(fim['need_help']&age['middle']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule22 = ctrl.Rule(fim['need_help']&age['middle']&hand_strength['non_range'],(time_hand['level2'],hand_level['level2']))
rule23 = ctrl.Rule(fim['need_help']&age['middle']&hand_strength['weak'],(time_hand['level3'],hand_level['level3']))
rule24 = ctrl.Rule(fim['need_help']&age['middle']&hand_strength['rather'],(time_hand['level5'],hand_level['level5']))
rule25 = ctrl.Rule(fim['need_help']&age['middle']&hand_strength['normal'],(time_hand['level7'],hand_level['level7']))

rule26 = ctrl.Rule(fim['need_help']&age['young']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule27 = ctrl.Rule(fim['need_help']&age['young']&hand_strength['non_range'],(time_hand['level3'],hand_level['level3']))
rule28 = ctrl.Rule(fim['need_help']&age['young']&hand_strength['weak'],(time_hand['level5'],hand_level['level5']))
rule29 = ctrl.Rule(fim['need_help']&age['young']&hand_strength['rather'],(time_hand['level7'],hand_level['level7']))
rule30 = ctrl.Rule(fim['need_help']&age['young']&hand_strength['normal'],(time_hand['level9'],hand_level['level9']))

rule31 = ctrl.Rule(fim['independence']&age['old']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule32 = ctrl.Rule(fim['independence']&age['old']&hand_strength['non_range'],(time_hand['level2'],hand_level['level2']))
rule33 = ctrl.Rule(fim['independence']&age['old']&hand_strength['weak'],(time_hand['level4'],hand_level['level3']))
rule34 = ctrl.Rule(fim['independence']&age['old']&hand_strength['rather'],(time_hand['level6'],hand_level['level4']))
rule35 = ctrl.Rule(fim['independence']&age['old']&hand_strength['normal'],(time_hand['level8'],hand_level['level6']))

rule36 = ctrl.Rule(fim['independence']&age['middle']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule37 = ctrl.Rule(fim['independence']&age['middle']&hand_strength['non_range'],(time_hand['level3'],hand_level['level2']))
rule38 = ctrl.Rule(fim['independence']&age['middle']&hand_strength['weak'],(time_hand['level5'],hand_level['level4']))
rule39 = ctrl.Rule(fim['independence']&age['middle']&hand_strength['rather'],(time_hand['level8'],hand_level['level6']))
rule40 = ctrl.Rule(fim['independence']&age['middle']&hand_strength['normal'],(time_hand['level10'],hand_level['level8']))

rule41 = ctrl.Rule(fim['independence']&age['young']&hand_strength['non_activation'],(time_hand['level1'],hand_level['level1']))
rule42 = ctrl.Rule(fim['independence']&age['young']&hand_strength['non_range'],(time_hand['level4'],hand_level['level3']))
rule43 = ctrl.Rule(fim['independence']&age['young']&hand_strength['weak'],(time_hand['level7'],hand_level['level5']))
rule44 = ctrl.Rule(fim['independence']&age['young']&hand_strength['rather'],(time_hand['level10'],hand_level['level8']))
rule45 = ctrl.Rule(fim['independence']&age['young']&hand_strength['normal'],(time_hand['level12'],hand_level['level10']))

rulea1 = ctrl.Rule(fim['dependence']&age['old']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea2 = ctrl.Rule(fim['dependence']&age['old']&leg_strength['non_range'],(time_leg['level1'],leg_level['level2']))
rulea3 = ctrl.Rule(fim['dependence']&age['old']&leg_strength['weak'],(time_leg['level1'],leg_level['level3']))
rulea4 = ctrl.Rule(fim['dependence']&age['old']&leg_strength['rather'],(time_leg['level2'],leg_level['level4']))
rulea5 = ctrl.Rule(fim['dependence']&age['old']&leg_strength['normal'],(time_leg['level2'],leg_level['level4']))

rulea6 = ctrl.Rule(fim['dependence']&age['middle']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea7 = ctrl.Rule(fim['dependence']&age['middle']&leg_strength['non_range'],(time_leg['level2'],leg_level['level2']))
rulea8 = ctrl.Rule(fim['dependence']&age['middle']&leg_strength['weak'],(time_leg['level3'],leg_level['level3']))
rulea9 = ctrl.Rule(fim['dependence']&age['middle']&leg_strength['rather'],(time_leg['level4'],leg_level['level4']))
rulea10 = ctrl.Rule(fim['dependence']&age['middle']&leg_strength['normal'],(time_leg['level4'],leg_level['level6']))

rulea11 = ctrl.Rule(fim['dependence']&age['young']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea12 = ctrl.Rule(fim['dependence']&age['young']&leg_strength['non_range'],(time_leg['level2'],leg_level['level2']))
rulea13 = ctrl.Rule(fim['dependence']&age['young']&leg_strength['weak'],(time_leg['level3'],leg_level['level4']))
rulea14 = ctrl.Rule(fim['dependence']&age['young']&leg_strength['rather'],(time_leg['level4'],leg_level['level6']))
rulea15 = ctrl.Rule(fim['dependence']&age['young']&leg_strength['normal'],(time_leg['level6'],leg_level['level8']))

rulea16 = ctrl.Rule(fim['need_help']&age['old']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea17 = ctrl.Rule(fim['need_help']&age['old']&leg_strength['non_range'],(time_leg['level2'],leg_level['level2']))
rulea18 = ctrl.Rule(fim['need_help']&age['old']&leg_strength['weak'],(time_leg['level3'],leg_level['level3']))
rulea19 = ctrl.Rule(fim['need_help']&age['old']&leg_strength['rather'],(time_leg['level4'],leg_level['level4']))
rulea20 = ctrl.Rule(fim['need_help']&age['old']&leg_strength['normal'],(time_leg['level5'],leg_level['level5']))

rulea21 = ctrl.Rule(fim['need_help']&age['middle']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea22 = ctrl.Rule(fim['need_help']&age['middle']&leg_strength['non_range'],(time_leg['level2'],leg_level['level2']))
rulea23 = ctrl.Rule(fim['need_help']&age['middle']&leg_strength['weak'],(time_leg['level3'],leg_level['level3']))
rulea24 = ctrl.Rule(fim['need_help']&age['middle']&leg_strength['rather'],(time_leg['level5'],leg_level['level5']))
rulea25 = ctrl.Rule(fim['need_help']&age['middle']&leg_strength['normal'],(time_leg['level7'],leg_level['level7']))

rulea26 = ctrl.Rule(fim['need_help']&age['young']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea27 = ctrl.Rule(fim['need_help']&age['young']&leg_strength['non_range'],(time_leg['level3'],leg_level['level3']))
rulea28 = ctrl.Rule(fim['need_help']&age['young']&leg_strength['weak'],(time_leg['level5'],leg_level['level5']))
rulea29 = ctrl.Rule(fim['need_help']&age['young']&leg_strength['rather'],(time_leg['level7'],leg_level['level7']))
rulea30 = ctrl.Rule(fim['need_help']&age['young']&leg_strength['normal'],(time_leg['level9'],leg_level['level9']))

rulea31 = ctrl.Rule(fim['independence']&age['old']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea32 = ctrl.Rule(fim['independence']&age['old']&leg_strength['non_range'],(time_leg['level2'],leg_level['level2']))
rulea33 = ctrl.Rule(fim['independence']&age['old']&leg_strength['weak'],(time_leg['level4'],leg_level['level3']))
rulea34 = ctrl.Rule(fim['independence']&age['old']&leg_strength['rather'],(time_leg['level6'],leg_level['level4']))
rulea35 = ctrl.Rule(fim['independence']&age['old']&leg_strength['normal'],(time_leg['level8'],leg_level['level6']))

rulea36 = ctrl.Rule(fim['independence']&age['middle']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea37 = ctrl.Rule(fim['independence']&age['middle']&leg_strength['non_range'],(time_leg['level3'],leg_level['level2']))
rulea38 = ctrl.Rule(fim['independence']&age['middle']&leg_strength['weak'],(time_leg['level5'],leg_level['level4']))
rulea39 = ctrl.Rule(fim['independence']&age['middle']&leg_strength['rather'],(time_leg['level8'],leg_level['level6']))
rulea40 = ctrl.Rule(fim['independence']&age['middle']&leg_strength['normal'],(time_leg['level10'],leg_level['level8']))

rulea41 = ctrl.Rule(fim['independence']&age['young']&leg_strength['non_activation'],(time_leg['level1'],leg_level['level1']))
rulea42 = ctrl.Rule(fim['independence']&age['young']&leg_strength['non_range'],(time_leg['level4'],leg_level['level3']))
rulea43 = ctrl.Rule(fim['independence']&age['young']&leg_strength['weak'],(time_leg['level7'],leg_level['level5']))
rulea44 = ctrl.Rule(fim['independence']&age['young']&leg_strength['rather'],(time_leg['level10'],leg_level['level8']))
rulea45 = ctrl.Rule(fim['independence']&age['young']&leg_strength['normal'],(time_leg['level12'],leg_level['level10']))
powering_ctrl = ctrl.ControlSystem([rule1,rule2,rule3,rule4,rule5,rule6,rule7,rule8,rule9,rule10,rule11,rule12,rule13,rule14,rule15
                                    ,rule16,rule17,rule18,rule19,rule20,rule21,rule22,rule23,rule24,rule25,rule26,rule27,rule28,rule29,rule30
                                    ,rule31,rule32,rule33,rule34,rule35,rule36,rule37,rule38,rule39,rule40,rule41,rule42,rule43,rule44,rule45
                                    ,rulea1,rulea2,rulea3,rulea4,rulea5,rulea6,rulea7,rulea8,rulea9,rulea10,rulea11,rulea12,rulea13,rulea14,rulea15
                                    ,rulea16,rulea17,rulea18,rulea19,rulea20,rulea21,rulea22,rulea23,rulea24,rulea25,rulea26,rulea27,rulea28,rulea29,rulea30
                                    ,rulea31,rulea32,rulea33,rulea34,rulea35,rulea36,rulea37,rulea38,rulea39,rulea40,rulea41,rulea42,rulea43,rulea44,rulea45])
powering= ctrl.ControlSystemSimulation(powering_ctrl)

f = open('F:\WorkSpace\GitHub\DoAn\VLTL\Assets\Data\Data.txt', 'r')
powering.input['fim'] = int(f.readline())
powering.input['leg_strength'] = float(f.readline())
powering.input['hand_strength'] = float(f.readline())
powering.input['age'] = int(f.readline())
# powering.input['fim'] = 21
# powering.input['leg_strength'] = 2
# powering.input['hand_strength'] = 3
# powering.input['age'] =2
powering.compute()
print(int(powering.output['time_hand']))
print(int(powering.output['hand_level']))
print(int(powering.output['leg_level']))
print(int(powering.output['time_leg']))


