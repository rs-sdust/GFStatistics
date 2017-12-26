args<-commandArgs(TRUE)
str01<-args[1]
str02<-args[2]
library(randomForest)
ROI<-read.csv(str01,header=T)
str<-"randomForest(formula = ClassROI~.,data = ROI,ntree = 500,mtry = 3,proximity = TRUE,importance = TRUE)"
print(str)
result<-randomForest(formula = ClassROI~.,data = ROI,ntree = 500,mtry = 3,proximity = TRUE,importance = TRUE)
print(result)
er.rate<-round(result$err.rate[result$ntree, "OOB"] * 100, digits = 2)
precision<-(100-er.rate)
#�����һ����Ҫ��ָ��
importance120<-importance(result,type=1)
# ��ӡ��Ҫ��
print(importance120)
#���ݵڶ��н�����������
Temp<-importance120[order(importance120[,1]),] 
#����ת��
t(Temp)  
print(t(Temp))
hebing=merge(precision,t(Temp))
write.csv(hebing, file = str02)