import cv2
import mediapipe as mp
import math
import pandas as pd
import csv
from sklearn.tree import DecisionTreeRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
import numpy as np
from VideoGetter import VideoGetter
from VideoShow import VideoShow
#from ReadSerial import Read
import serial.tools.list_ports

ports = serial.tools.list_ports.comports()
serialIns = serial.Serial()
serialIns.baudrate = 115200
serialIns.port  = 'COM3'
serialIns.open()

video_path = "F:/VideoTest/test.mp4"
mp_drawing = mp.solutions.drawing_utils
mp_drawing_styles = mp.solutions.drawing_styles
mp_pose = mp.solutions.pose

def read(index):
    while True:
        if serialIns.in_waiting:
            packet = serialIns.readline()
            receive = packet.decode('utf').split(',')
            if len(receive) == 4 :
                return receive[index]

def perceptron():
    f = open('F:\WorkSpace\GitHub\DoAn\VLTL\Assets\Data\DataAngle.txt', 'r')
    df = pd.read_csv('Dataleft.csv', header=None)
    dataset =df.iloc[:, 3:7].drop(index=[0]).astype(np.float)
    out = df.iloc[:, 1:3].drop(index=[0]).astype(np.float)
    X = np.array(dataset)
    y = np.array(out)
    # define model
    model = DecisionTreeRegressor()
    # fit model
    model.fit(X, y)
    # make a prediction
    row = [GetData(11,13,0).L,GetData(13,15,0).L,GetData(11,15,0).L,f.readline()]
    yhat = model.predict([row])
    return yhat[0]

class GetData(): 
    def __init__(self, point1, point2,point3):
        ax=results.pose_world_landmarks.landmark[point1].x
        ay=results.pose_world_landmarks.landmark[point1].y
        az=results.pose_world_landmarks.landmark[point1].z
        bx=results.pose_world_landmarks.landmark[point2].x
        by=results.pose_world_landmarks.landmark[point2].y
        bz=results.pose_world_landmarks.landmark[point2].z
        cx=results.pose_world_landmarks.landmark[point3].x
        cy=results.pose_world_landmarks.landmark[point3].y
        cz=results.pose_world_landmarks.landmark[point3].z
        a= ax-bx
        a_=cx-bx
        b=ay-by
        b_=cy-by
        c=az-bz
        c_=cz-bz
        self.oxyz=math.acos((abs(a*a_+b*b_+c*c_))/(math.sqrt((a**2+b**2+c**2)*(a_**2+b_**2+c_**2))))
        self.L = math.sqrt((a)**2 + (b)**2 + (c)**2)

def SaveData():
    rows = ['phải',GetData(23,11,13).oxyz,GetData(11,13,15).oxyz,
            GetData(11,13,0).L,GetData(13,15,0).L,GetData(11,15,0).L,armL,
            GetData(11,23,25).oxyz,GetData(23,25,27).oxyz,
            GetData(23,25,0).L,GetData(25,27,0).L,GetData(23,27,0).L,armA,"1"]
    with open('Dataleft.csv', 'a', encoding='UTF8', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(rows)

cap = VideoGetter(0).start()
show = VideoShow(cap.frame).start()
with mp_pose.Pose(min_detection_confidence=0.5,min_tracking_confidence=0.5) as pose:
  while cap.isOpen:

    # To improve performance, optionally mark the image as not writeable to
    # pass by reference.
    image=cap.frame
    image.flags.writeable = False
    image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
    results = pose.process(image)

    # Draw the pose annotation on the image.
    image.flags.writeable = True
    image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
    mp_drawing.draw_landmarks(image,results.pose_landmarks, mp_pose.POSE_CONNECTIONS,landmark_drawing_spec=mp_drawing_styles.get_default_pose_landmarks_style())
    # Flip the image horizontally for a selfie-view display.
    show.frame = image
  
    if results.pose_world_landmarks!=None:
        SaveData()
        perceptron()
    if cv2.waitKey(5) & 0xFF == ord('q'):
        cap.stop()
        break